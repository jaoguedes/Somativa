# Somativa

O Arquivo de Script na instalação (Usuarios Correcao Sprint)  cria os usuários e perfis:


LOGIN⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀SENHA
-------------------------------------------------------------
admin@admin.com⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀@Adm1n1234


operador@operador.com⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀@Op3r4dor


gerente@gerente.com⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀@G3r3nt3


### 📋 FIGMA

https://www.figma.com/file/K1YVFljOMGTgXUMMnHvPKZ/Untitled?type=design&node-id=0%3A1&mode=design&t=pBpLUz3Kzoxnqcc3-1

### 🔧 Instalação

Uma série de exemplos passo-a-passo que informam o que você deve executar para ter um ambiente de desenvolvimento em execução.

#### Nesse campo:

"DefaultConnection": "Data Source=SB-1491266\\SQLSENAI;Initial Catalog=dbSprint;Integrated Security=True;TrustServerCertificate=True"

#### Altere essa parte:

```
SB-1491266\SQLSENAI
```

Ache o nome da sua maquina e subistua por esse campo acima

#### Depois execute:


```
update-database -Context SprintContext
```
```
update-database -Context ApplicationDbContext
```

#### Logo depois no seu banco de dados crie uma nova consulta e cole esse codigo abaixo:  
### Usuarios Correcao Sprint

```
use dbSprint
Go
Delete from AspNetUserRoles
Go
Delete from AspNetUsers
Go
Delete from AspNetRoles
Go
Insert Into AspNetUsers
Values ('2ed084a4-81b6-46f2-9adc-eb661f857e0d',	'gerente@gerente.com',	'GERENTE@GERENTE.COM',	'gerente@gerente.com',	'GERENTE@GERENTE.COM',	0,	'AQAAAAIAAYagAAAAEEbvcjokOr3e4IndPwgVvAb4mG7H5t6JuTvDY+aHFTe4DGep1PgY8MFG2dJ48VRQnA==',	'ZEQK6UB245AI6PSJE3BV7WJPS47TLP5Q',	'3d71b8a0-0fb0-4788-b609-1dc73e41fd69',	NULL,	0,	0,	NULL,	1,	0)
Go
Insert Into AspNetUsers
Values ('564f7fb6-8b74-4110-a2ed-f2b4f3e7754c',	'operador@operador.com', 'OPERADOR@OPERADOR.COM', 'operador@operador.com',	'OPERADOR@OPERADOR.COM', 0,	'AQAAAAIAAYagAAAAEJ9TXWsFZUv7jOBCQCSWSxLtEjAuhGAy9HnInoY8Ss/X0jPsG0BRChlV35qvDKB/NA==',	'UDZN7GNVCMDNKBODM7SQG5FOXKLV22RG',	'5453fe2d-b0a2-4206-a282-7e204c4b4abf',	NULL,	0,	0,	NULL,	1,	0)
Go
Insert Into AspNetUsers
Values ('bf5c9c1e-2b8f-4137-aace-bf76022ee09b',	'admin@admin.com',	'ADMIN@ADMIN.COM',	'admin@admin.com',	'ADMIN@ADMIN.COM',	0,	'AQAAAAIAAYagAAAAEIngFpD6EaYkg0CxOLCLSw7YURdbRTQ1fTH6utP4kReNjM52YEDwWzNWogpNwNSUpQ==',	'MUOWAAMLKVTKHRTFPDEHF64VOHLNJ3LB',	'895dd908-c6f1-491c-97d3-6b10911f35ff',	NULL,	0,	0,	NULL,	1,	0)
Go
Insert Into AspNetRoles
Values ('4D153634-BFFB-4029-9A3F-BC651F538FA6',	'Operador',	'OPERADOR',	'BA7F640E-6172-4A46-B68E-C407D42E781A')
Go
Insert Into AspNetRoles
Values ('6FBAD156-288A-439D-8E8C-DF05F68DBCB0',	'Admin', 'ADMIN', '01DDC2CF-1F56-4818-993B-741BBFBC565C')
Go
Insert Into AspNetRoles
Values ('AFC3941D-CADA-46B7-BF95-BC2C4BCA3564',	'Gerente',	'GERENTE', 'D096E7A3-0886-4941-B2D7-D5361E1C5CBE')
Go
Insert Into AspNetUserRoles
Values ('564f7fb6-8b74-4110-a2ed-f2b4f3e7754c',	'4D153634-BFFB-4029-9A3F-BC651F538FA6')
Go
Insert Into AspNetUserRoles
Values ('bf5c9c1e-2b8f-4137-aace-bf76022ee09b',	'6FBAD156-288A-439D-8E8C-DF05F68DBCB0')
Go
Insert Into AspNetUserRoles
Values ('2ed084a4-81b6-46f2-9adc-eb661f857e0d',	'AFC3941D-CADA-46B7-BF95-BC2C4BCA3564')
Go
```

## 📌 Propriedades

Nós usamos [.Net](https://learn.microsoft.com/en-us/dotnet/core/introduction) e para o estilo [Bootstrap](https://getbootstrap.com/docs/5.3/getting-started/introduction/).

## ✒️ Integrantes

Todos os Integrantes do projeto

* **Guedes** - *Programação* - [jaoguedes](https://github.com/jaoguedes)
* **Yasmin** - *Figma* - [Yasmimmmmm](https://github.com/Yasmimmmmm)
* **Gustavo** - *Figma* - [Gustavo-RCS](https://github.com/Gustavo-RCS)


---
#### esse é o fim, tenha um bom dia 😊
