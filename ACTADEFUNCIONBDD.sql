create database Actas
go
use Actas
create table ACTA_INSCRIPCION (
   ACTAINSCRIPCION      varchar(40)          not null,
   IDREGISTROCIVIL      int                  null,
   ID_FETAL             int                  null,
   CI_MADRE             int                  null,
   CI_MEDICO            int                  null,
   FECHAINSCRIPCION     varchar(30)             not null,        
   constraint PK_ACTA_INSCRIPCION primary key (ACTAINSCRIPCION)
)
create table DEF_FETAL (
   ID_FETAL             int                  not null,  
   SEXOFETO             char(30)             not null,
   SEMANAGESTA          int             not null,
   FECHADEFUN           varchar(30)             not null,
   PRODUCTOEMBARA       char(20)             not null,
   ASISTENCIAFETAL      char(30)             not null,
   LUGAROCURRENCIA      char(30)              null,
   NOMBREESTABLEFETAL   char(30)              null,
   PROVINCIAFETAL       char(30)              null,
   CANTONFETAL          char(30)              null,
   PARROQUIAFETAL       char(30)              null,
   LOCALIDADFETAL       char(30)              null,
   CAUSAFETAL           char(30)             not null,
   constraint PK_DEF_FETAL primary key nonclustered (ID_FETAL)
)
create table MADRE (
   CI_MADRE             int                  not null,
   NOMBREMADRE          char(50)             not null,
   NACIONALMADRE        char(30)             not null,
   FECHANACIMIMADRE     varchar(30)             not null,
   EDADMADRE            int                  not null,
   HIJOSVIVEN           smallint             not null,
   HIJOSMUERTOSVIVEN    smallint             not null,
   HIJOSMUERTOS         smallint             not null,
   NUMCONTROLES         int                  not null,
   AUTOMADRE            char(20)             not null,
   ESTADOCIVIL          char(30)             not null,
   LECTURA              char(20)             not null,
   NIVELINSTRUCCIONMADRE char(40)              null,
   PROVINCIAMADRE       char(30)             not null,
   CANTONMADRE          char(30)             not null,
   PARROQUIAMADRE       char(40)             not null,
   CIUDADMADRE          char(30)             not null,
   DIREMADRE            char(40)             not null,
   constraint PK_MADRE primary key nonclustered (CI_MADRE)
)
create table MEDICO (
   CI_MEDICO            int                  not null,
   NOMBREMEDICO         char(30)             not null,
   NUMTELEMEDICO        int                  not null,
   FIRMAMEDICO          varchar(30)                 null,
   OBSERMEDICO          text                 not null,
   constraint PK_MEDICO primary key  (CI_MEDICO)
)
create table REGISTROCIVIL (
   IDREGISTROCIVIL      int                 not null,
   OFICINAREGISTRO   char(50)             not null,
   PARROQUIAREGISTRO    char(30)             not null,
   CANTONREGISTRO       char(30)             not null,
   PROVINCIAREGISTRO    char(30)             not null,
   constraint PK_REGISTROCIVIL primary key nonclustered(IDREGISTROCIVIL)
)
create table USUARIO(
	idUsuario int identity (1,1),
	nombre varchar(30) not null,
	contraseña varchar(30) not null
)
create table auditoria(
	auditoria int identity(1,1) ,
	ACTAINSCRIPCIO      varchar(40)          not null,
   IDREGISTROCIVI      int                  null,
   ID_FETA             int                  null,
   CI_MADR             int                  null,
   CI_MEDIC           int                  null,
   FECHAINSCRIPCIO     varchar(30)             not null,        
   constraint PK_auditoria primary key (auditoria))

insert into USUARIO(nombre,contraseña) values ('admin','admin');

create procedure MostrarTodo
@CI_madre int
as
select *from Acta_inscripcion A join Madre M
on M.ci_madre = A.Ci_madre join DEF_Fetal DF
on DF.ID_FETAL = A.ID_Fetal join Medico Med
on Med.ci_medico =A.ci_medico join RegistroCivil RC
on RC.idregistrocivil= A.idregistrocivil

CREATE TRIGGER insercionActas on Acta_inscripcion for
insert 
as


