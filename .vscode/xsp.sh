#!/usr/bin/env bash
# macOS 용 개발 서버 (Windows 의 start-iis.ps1 대응)
# IIS Express 대신 Docker 컨테이너 안의 Mono XSP4 로 사이트를 실행한다.
#   사용법: xsp.sh start [port] | xsp.sh stop
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT="$(cd "$SCRIPT_DIR/.." && pwd)"
IMAGE="sns2inc-xsp"
CONTAINER="sns2inc-xsp"

stop() {
    docker rm -f "$CONTAINER" >/dev/null 2>&1 || true
}

case "${1:-}" in
    start) ;;
    stop) stop; exit 0 ;;
    *) echo "usage: $0 start [port] | stop" >&2; exit 1 ;;
esac

PORT="${2:-55085}"

echo "Starting XSP ..."

if ! docker info >/dev/null 2>&1; then
    echo "Docker 가 실행 중이 아닙니다. Docker Desktop 을 먼저 실행하세요." >&2
    exit 1
fi

# 최초 1회만 실제로 빌드되고 이후에는 캐시 사용
docker build -t "$IMAGE" - < "$SCRIPT_DIR/xsp.Dockerfile"

stop

# 01.Office 폴더를 루트로 사용
MOUNTS=(-v "$ROOT/01.Office:/app/office")
APPS="/:/app/office"

# 04.Pda 폴더를 /PDA 경로로 매핑
if [ -d "$ROOT/04.Pda" ]; then
    MOUNTS+=(-v "$ROOT/04.Pda:/app/pda")
    APPS="$APPS,/PDA:/app/pda"
fi

exec docker run --rm --init --name "$CONTAINER" \
    -p "$PORT:$PORT" \
    "${MOUNTS[@]}" \
    "$IMAGE" \
    xsp4 --nonstop --address 0.0.0.0 --port "$PORT" --root /app/office --applications "$APPS"
