# Usa la imagen oficial de MongoDB
FROM mongo

# Establece un directorio de trabajo
WORKDIR /data

# Copia las bibliotecas del controlador MongoDB
COPY MongoDB.Bson.dll /usr/local/lib/MongoDB.Bson.dll
COPY MongoDB.Driver.dll /usr/local/lib/MongoDB.Driver.dll

# Expón el puerto de MongoDB
EXPOSE 27017

# Inicia el servidor de MongoDB
CMD ["mongod"]
