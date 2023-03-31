FROM envoyproxy/envoy:v1.25.1
RUN apt-get update
COPY ./envoy.yaml /etc/envoy/envoy.yaml
CMD /usr/local/bin/envoy -c /etc/envoy/envoy.yaml