# Sofia's sandbox project for back-end project

Name | Value
--- | ---
Language | C#
Database | Postgres
Deployed | https://webapp-sandbox-sofia.herokuapp.com

### The application running
![ScreenShot](/Screenshots/app-screenshot.png)

## How to run in Docker from the commandline

Execute the commands below in [AspNetSandBox](AspNetSandBox) directory

### Build in container
```
docker build -t web_sofia .
```

to run

```
docker run -d -p 8081:80 --name web_container_sofia web_sofia
```

to stop container
```
docker stop web_container_sofia
```

to remove container
```
docker rm web_container_sofia
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a webapp-sandbox-sofia web
```

Release the container
```
heroku container:release -a webapp-sandbox-sofia web
```