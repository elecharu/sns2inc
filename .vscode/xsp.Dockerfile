# macOS 개발용 ASP.NET(WebForms) 서버 이미지: Mono + XSP4 (xsp.sh 에서 빌드)
FROM mono:6.12

# Debian 10(buster)은 지원 종료되어 archive.debian.org 로 바꿔야 apt 가 동작함
RUN sed -i \
        -e 's|deb.debian.org/debian-security|archive.debian.org/debian-security|' \
        -e 's|deb.debian.org/debian |archive.debian.org/debian |' \
        -e '/buster-updates/d' \
        /etc/apt/sources.list \
    && apt-get update \
    && DEBIAN_FRONTEND=noninteractive apt-get install -y --no-install-recommends mono-xsp4 fonts-nanum \
    && rm -rf /var/lib/apt/lists/*

# Windows 개발 PC 와 동일하게 한국 시간대/문화권으로 실행
ENV TZ=Asia/Seoul \
    LANG=ko_KR.UTF-8
