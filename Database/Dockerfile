FROM microsoft/mssql-server-linux as build

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=SecureP@ssw0rd
# this is the default: ENV MSSQL_PID=Developer
# see https://hub.docker.com/r/microsoft/mssql-server-linux/

WORKDIR /tmp
COPY prod-database.bak .
COPY prod-to-dev.sql .

RUN /opt/mssql/bin/sqlservr --accept-eula & sleep 20 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P SecureP@ssw0rd -i /tmp/prod-to-dev.sql \
    && pkill sqlservr


FROM microsoft/mssql-server-linux as dev

ENV ACCEPT_EULA=Y
# SA_PASSWORD is already baked into database

COPY --from=build /var/opt/mssql/data /var/opt/mssql/data

