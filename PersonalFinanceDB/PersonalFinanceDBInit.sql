IF DB_ID('PersonalFinance') IS NULL
BEGIN
    create DATABASE PersonalFinance;
END
GO
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'FinanceBroker')
BEGIN
    Create LOGIN FinanceBroker WITH PASSWORD= '$(FinanceBroker)';
END
GO
USE PersonalFinance;
go
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'FinanceBroker')
BEGIN
    CREATE USER FinanceBroker for LOGIN FinanceBroker;
    GRANT CREATE TABLE TO FinanceBroker;
    GRANT ALTER TO FinanceBroker;
    GRANT DELETE TO FinanceBroker;
    GRANT INSERT TO FinanceBroker;
    GRANT UPDATE TO FinanceBroker;
    GRANT REFERENCES TO FinanceBroker; -- Para Foreign Keys
    GRANT VIEW DEFINITION TO FinanceBroker;

    GRANT CONNECT TO FinanceBroker;
    GRANT DELETE, INSERT, SELECT, UPDATE TO FinanceBroker;

    -- Permitir eliminar objetos si EF lo requiere
    GRANT CONTROL ON SCHEMA::dbo TO FinanceBroker;
END
GO