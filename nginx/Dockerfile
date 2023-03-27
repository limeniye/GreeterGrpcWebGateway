FROM nginx:1.23.3
WORKDIR /app
EXPOSE 443
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY ./snippets /etc/nginx/snippets
COPY ./cert/server.crt /etc/ssl/certs/server.crt
COPY ./cert/server.key /etc/ssl/private/server.key
CMD ["nginx", "-g", "daemon off;"]