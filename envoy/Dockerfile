FROM envoyproxy/envoy:v1.25.1
RUN apt-get update
COPY ./envoy.yaml /etc/envoy/envoy.yaml
COPY ./protos/greet_definition.pb /data/greet_definition.pb
CMD /usr/local/bin/envoy -c /etc/envoy/envoy.yaml
