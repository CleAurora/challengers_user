docker pull mcr.microsoft.com/mssql/server:2019-CTP2.1-ubuntu
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MSSQL!2020' -p 1433:1433 --name mssql -d mcr.microsoft.com/mssql/server
