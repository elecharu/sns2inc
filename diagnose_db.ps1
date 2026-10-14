[System.Reflection.Assembly]::LoadFrom("d:\ITS_MES_SNSINC_FAC2_VA.1.0\01.Office\Bin\MySql.Data.dll") | Out-Null
$connStr = "server=211.43.15.98;port=33061;uid=root;pwd='its1005[]';database=MES_SNS2;"
$conn = New-Object MySql.Data.MySqlClient.MySqlConnection($connStr)
try {
    $conn.Open()
    Write-Host "=== DB CONNECTED ==="
    
    $cmd = $conn.CreateCommand()

    # 1. MTRODR 전체 최신 발주일자 확인
    Write-Host "`n[1. MTRODR 전체 최신 발주일자 TOP 5]"
    $cmd.CommandText = "SELECT MTRODRKEY, MTRODRDATE, ODRFACTORY, INFACTORYCD, CUSTCD FROM MTRODR ORDER BY MTRODRDATE DESC LIMIT 5"
    $r = $cmd.ExecuteReader()
    while ($r.Read()) {
        Write-Host ($r["MTRODRKEY"] + " | Date: " + $r["MTRODRDATE"] + " | OdrFac: " + $r["ODRFACTORY"] + " | InFac: " + $r["INFACTORYCD"] + " | Cust: " + $r["CUSTCD"])
    }
    $r.Close()

    # 2. 설비부품 발주 중 최신 발주일자 TOP 10
    Write-Host "`n[2. 설비부품(DM1007%)이 포함된 발주 최신 TOP 10]"
    $cmd.CommandText = "
      SELECT O.MTRODRKEY, O.MTRODRDATE, O.ODRFACTORY, O.INFACTORYCD, O.CUSTCD, C.CUSTNM,
             COUNT(D.MTRODRSEQ) AS ITEM_CNT
      FROM MTRODR O
      INNER JOIN MTRODRD D ON D.MTRODRKEY = O.MTRODRKEY
      INNER JOIN MSTITEM I ON I.ITEMID = D.ITEMID
      LEFT JOIN MSTCUST C ON C.CUSTCD = O.CUSTCD
      WHERE (I.ITEMCG = 'DM100700' OR I.ITEMCG LIKE 'DM1007%' OR I.ITEMCG = 'DM100750')
      GROUP BY O.MTRODRKEY, O.MTRODRDATE, O.ODRFACTORY, O.INFACTORYCD, O.CUSTCD, C.CUSTNM
      ORDER BY O.MTRODRDATE DESC, O.MTRODRKEY DESC
      LIMIT 10
    "
    $r = $cmd.ExecuteReader()
    while ($r.Read()) {
        Write-Host ($r["MTRODRDATE"] + " | Key: " + $r["MTRODRKEY"] + " | Fac: " + $r["INFACTORYCD"] + " | Cust: " + $r["CUSTNM"] + " | Items: " + $r["ITEM_CNT"])
    }
    $r.Close()

    # 3. 설비부품 발주에서 MSTITEM.COMPANYCD 값 분포 확인
    Write-Host "`n[3. 설비부품 발주 품목의 MSTITEM.COMPANYCD 분포]"
    $cmd.CommandText = "
      SELECT I.COMPANYCD, COUNT(*) AS CNT
      FROM MTRODRD D
      INNER JOIN MSTITEM I ON I.ITEMID = D.ITEMID
      WHERE (I.ITEMCG = 'DM100700' OR I.ITEMCG LIKE 'DM1007%' OR I.ITEMCG = 'DM100750')
      GROUP BY I.COMPANYCD
    "
    $r = $cmd.ExecuteReader()
    while ($r.Read()) {
        Write-Host ("COMPANYCD: '" + $r["COMPANYCD"] + "' | Count: " + $r["CNT"])
    }
    $r.Close()

    # 4. 공장코드(*FACTORYCD) 공통코드 조회
    Write-Host "`n[4. *FACTORYCD 공통코드 목록]"
    $cmd.CommandText = "
      SELECT TPCD, TPNM, REF01, REF02 FROM COMTYPE WHERE GPCD = '*FACTORYCD' ORDER BY SORTNO, TPCD
    "
    $r = $cmd.ExecuteReader()
    while ($r.Read()) {
        Write-Host ("Code: " + $r["TPCD"] + " | Name: " + $r["TPNM"] + " | REF01: " + $r["REF01"])
    }
    $r.Close()

    # 5. 설비부품 발주에서 ODRFACTORY / INFACTORYCD 값 분포 확인
    Write-Host "`n[5. 설비부품 발주의 ODRFACTORY / INFACTORYCD 분포]"
    $cmd.CommandText = "
      SELECT O.ODRFACTORY, O.INFACTORYCD, COUNT(DISTINCT O.MTRODRKEY) AS ODR_CNT
      FROM MTRODR O
      INNER JOIN MTRODRD D ON D.MTRODRKEY = O.MTRODRKEY
      INNER JOIN MSTITEM I ON I.ITEMID = D.ITEMID
      WHERE (I.ITEMCG = 'DM100700' OR I.ITEMCG LIKE 'DM1007%' OR I.ITEMCG = 'DM100750')
      GROUP BY O.ODRFACTORY, O.INFACTORYCD
    "
    $r = $cmd.ExecuteReader()
    while ($r.Read()) {
        Write-Host ("ODRFACTORY: '" + $r["ODRFACTORY"] + "' | INFACTORYCD: '" + $r["INFACTORYCD"] + "' | Orders: " + $r["ODR_CNT"])
    }
    $r.Close()

    # 6. 화면 파라미터 시뮬레이션 ($COMPANYCD='60', $FACTORYCD='02' or '2공장', $SDATE='2026-01-01', $EDATE='2026-12-31')
    Write-Host "`n[6. 프로시저 파라미터 시뮬레이션]"
    $testParams = @(
        @{ Label = "전체 기간(2026년), 공장무관, 법인60"; Sql = "WHERE (COALESCE('60','')='' OR I.COMPANYCD='60') AND (LEFT(REPLACE(MTRODR.MTRODRDATE,'-',''),8) BETWEEN '20260101' AND '20261231')" },
        @{ Label = "전체 기간(2026년), INFACTORYCD='02', 법인60"; Sql = "WHERE (COALESCE('60','')='' OR I.COMPANYCD='60') AND MTRODR.INFACTORYCD='02' AND (LEFT(REPLACE(MTRODR.MTRODRDATE,'-',''),8) BETWEEN '20260101' AND '20261231')" },
        @{ Label = "최근 7일(2026-10-07~2026-10-14), 공장무관"; Sql = "WHERE (LEFT(REPLACE(MTRODR.MTRODRDATE,'-',''),8) BETWEEN '20261007' AND '20261014')" }
    )
    foreach ($tp in $testParams) {
        $cmd.CommandText = "
          SELECT COUNT(DISTINCT MTRODR.MTRODRKEY) AS CNT
          FROM MTRODR
          INNER JOIN (
            SELECT DISTINCT D.MTRODRKEY
            FROM MTRODRD D
            INNER JOIN MSTITEM I ON I.ITEMID = D.ITEMID
            WHERE (I.ITEMCG = 'DM100700' OR I.ITEMCG LIKE 'DM1007%' OR I.ITEMCG = 'DM100750')
          ) EQM_ODR ON EQM_ODR.MTRODRKEY = MTRODR.MTRODRKEY
          LEFT JOIN MSTITEM I ON 1=1
          " + $tp.Sql
        $cnt = $cmd.ExecuteScalar()
        Write-Host ($tp.Label + " => 건수: " + $cnt)
    }

} catch {
    Write-Host "ERROR: " $_.Exception.Message
} finally {
    $conn.Close()
}
