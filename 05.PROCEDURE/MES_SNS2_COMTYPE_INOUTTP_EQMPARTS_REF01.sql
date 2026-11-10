-- *****************************************************************************
-- Comment: 설비부품 입출고구분(INOUTTP_EQMPARTS) REF01에 입고(IN)·출고(OUT) 구분 등록
--          출고구분 콤보(TML1010_R05 출고 팝업, TAL0001_R09 출고 등록 창)가 REF01="OUT"으로 출고 코드만 표시
--          부자재 입출고구분(INOUTTP_PRDCONSUM, TML1030_R01 REF01="OUT")과 같은 방식
-- Create:  2026-11-10  한성수
-- *****************************************************************************

-- 현재 값 확인 (INOUTTP_PRDCONSUM의 REF01 값과 같은 형식인지 비교)
SELECT GPCD, TPCD, TPNM, REF01
FROM MES_SNS2.COMTYPE
WHERE GPCD IN ('INOUTTP_EQMPARTS', 'INOUTTP_PRDCONSUM')
ORDER BY GPCD, TPCD;

-- 입고 코드(IN_)는 'IN', 출고 코드(OUT_)는 'OUT'
START TRANSACTION;
UPDATE MES_SNS2.COMTYPE
SET REF01 = 'IN'
WHERE GPCD = 'INOUTTP_EQMPARTS'
  AND TPCD LIKE 'IN\_%';

UPDATE MES_SNS2.COMTYPE
SET REF01 = 'OUT'
WHERE GPCD = 'INOUTTP_EQMPARTS'
  AND TPCD LIKE 'OUT\_%';
COMMIT;

-- 결과 확인 (IN_01 구매입고 = IN, OUT_01 부품교체 = OUT)
SELECT GPCD, TPCD, TPNM, REF01
FROM MES_SNS2.COMTYPE
WHERE GPCD = 'INOUTTP_EQMPARTS'
ORDER BY TPCD;
