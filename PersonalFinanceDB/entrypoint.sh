#!/bin/bash

DATA_DIR="/var/opt/mssql/data"
MARKER_FILE="/var/opt/mssql/.initialized"

/opt/mssql/bin/sqlservr &

echo "Esperando a que SQL Server arranque..."
sleep 20

/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -i /init-db.sql

wait

if [ ! -f "$MARKER_FILE" ]; then
    echo "First initialization detected. Executing script..."

    /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -i /init-db.sql

    touch $MARKER_FILE
    echo "initialization completed."
else
    echo "SQL Server was initialized already. Skipping script."
fi

wait
