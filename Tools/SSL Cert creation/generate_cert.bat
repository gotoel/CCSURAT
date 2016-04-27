:: If you installed OpenSSL in non-default directory, you MUST change paths in commands.

@echo off
set OPENSSL_CONF=OpenSSL\bin\openssl.cfg

"OpenSSL\bin\openssl" req -x509 -nodes -days 365 -newkey rsa:1024 -keyout private.key -out cert.crt

"OpenSSL\bin\openssl" pkcs12 -export -in cert.crt -inkey private.key -out Server.pfx -passout pass:cs492

del .rnd
del private.key
del cert.crt