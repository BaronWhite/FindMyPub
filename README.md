# Find My Pub
This app allows you to browse pubs from the Leeds Beer Quest and find your favourite one. You can see existing reviewes (just click any pub!) or add your own.

Note: the app uses an in memory database seeded with data from the LBQ website, any new data is not persisted.

# Setup

## Find My Pub Web
The front end uses Angular 14 and can easily be served or built with `ng serve` or `ng build`. To run tests `ng test`.

### Docker
From the angular app root run:
```
docker build -t find-my-pub-web .
docker run -it  -p 8080:80 find-my-pub-web
```

## Find My Pub Api
The FindMyPubApi uses .net 6 and can be built and executed or run in docker.

### Docker

To run the api from docker, execute the build command from the api root folder (FindMyPubApi), include the -f parameter as the file lives in WebApi.

The api exposes both 80 an 433, in the below case we are mapping 80 to 5141 and 443 to 7141(configured in the Web proxy), and you can access it on http://localhost:2000/swagger/index.html.
```
docker build -t find-my-pub-api . -f .\FindMyPub.WebApi\Dockerfile && docker run -it  -p 7141:443 -p 5141:80 find-my-pub-api
```
