FROM mcr.microsoft.com/mssql/server:2022-latest AS build

# SA Password set here for demo.
# TODO: pass it in as a build arg
ARG SA_PASSWORD=SecureP@ssw0rd
ENV SA_PASSWORD=$SA_PASSWORD
ENV ACCEPT_EULA=Y
# this is the default: ENV MSSQL_PID=Developer
# see https://hub.docker.com/r/microsoft/mssql-server-linux/

WORKDIR /tmp
COPY prod-database.bak .
COPY prod-to-dev.sql .

# Start SQL Server, wait for it to be ready, then migrate the database
RUN /opt/mssql/bin/sqlservr --accept-eula & pid=$! \
    && echo "sqlservr started with pid $pid" \
    && i=0; while [ $i -lt 60 ]; do /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -Q "SELECT 1" -N -C && break || (sleep 1; i=$((i+1))); done \
    && /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -N -C -i /tmp/prod-to-dev.sql \
    && kill $pid


FROM mcr.microsoft.com/mssql/server:2022-latest AS dev

ENV ACCEPT_EULA=Y
# SA_PASSWORD is already baked into database
# prod-to-dev.sql set it to a development password

COPY --from=build --chown=mssql:root /var/opt/mssql /var/opt/mssql
