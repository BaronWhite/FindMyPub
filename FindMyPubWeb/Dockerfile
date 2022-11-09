FROM alpine AS builder

WORKDIR /app
COPY package.json .
RUN apk add --update nodejs npm
RUN npm i
COPY . .
RUN npm run build -- --progress false --output-path=dist 


FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*
COPY --from=builder /app/dist /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]
