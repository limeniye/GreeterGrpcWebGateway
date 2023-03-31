FROM nginx:1.23.3
WORKDIR /app
EXPOSE 443
COPY ./nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]