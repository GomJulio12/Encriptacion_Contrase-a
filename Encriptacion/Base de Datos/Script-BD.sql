Create database Encriptacion;

use Encriptacion;

-- Creamos una tabla de usuarios.
create table USUARIO (
id int not null auto_increment primary key,
nombre varchar (50) not null,
usuario varchar(45) not null,
password varchar(80) not null,
id_tipo int not null);

create table TIPO_USUARIO(
id_tipo int not null auto_increment primary key,
nombre varchar(50) not null);

ALTER TABLE `encriptacion`.`usuario` 
ADD INDEX `Fk_TipoUsuario_idx` (`id_tipo` ASC) VISIBLE;
;
ALTER TABLE `encriptacion`.`usuario` 
ADD CONSTRAINT `Fk_TipoUsuario`
  FOREIGN KEY (`id_tipo`)
  REFERENCES `encriptacion`.`tipo_usuario` (`id_tipo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

insert into TIPO_USUARIO (nombre) values ("Administrador"),("Usuario");