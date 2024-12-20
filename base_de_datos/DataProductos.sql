create database "producto"
    with
    template = template0
    encoding = 'UTF8'
    lc_collate = 'es_MX.UTF-8'
    lc_ctype = 'es_MX.UTF-8'
    connection limit = -1
    is_template = False;

   -- \c "prueba_sye";

create schema if not exists schemasye;


create table if not exists schemasye.tc_producto 
(
    idproducto serial,
    nombre varchar(255) not null,
    precio double precision not null,
	cantidad int not null,
	fecha_registrar date not null,
    estado boolean not null default true,
    primary key (idproducto)
);