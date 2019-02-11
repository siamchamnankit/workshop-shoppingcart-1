FROM microsoft/dotnet:2.0-sdk
WORKDIR /app
COPY ./ ./
ADD run.api.test.sh .
RUN chmod 755 run.api.test.sh
ENTRYPOINT ["/bin/bash", "-c", "./run.api.test.sh"]