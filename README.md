<h1 align="center">
    <img src="ConsumidorApi/assets/tela-terminal.png">
</h1>

# ConsumidorApi

Este projeto é uma API para gerenciar "Staffs" e "Cars" (Carros). Abaixo estão os principais controladores e serviços utilizados.

## Índice

- [Program.cs](#programcs)
- [Car Services](#car-services)
- [Staff Services](#staff-services)
- [Como rodar o projeto](#como-rodar-o-projeto)
- [Dependências](#dependências)
- [API Endpoints](#api-endpoints)

---

## Program.cs

O arquivo `Program.cs` contém o menu de operações que podem ser realizadas na API. As opções incluem buscar, listar, criar e deletar tanto "Staff" quanto "Car" (Carro).

### Menu de Opções:

<li> 1 - Buscar Staff</li>
<li>2 - Buscar Carro</li>
<li>3 - Listar Staffs</li>
<li>4 - Listar Carros</li>
<li>5 - Criar Carro</li>
<li>6 - Criar Staff</li>
<li>7 - Buscar Carro por Id da Staff</li>
<li>8 - Buscar Staff por Id do Carro</li>
<li>9 - DELETAR Staff por Id</li>
<li>10 - DELETAR Carro por Id</li>
<li>0 - Sair</li>



# Car Services

O **CarServices** é responsável por integrar a API e gerenciar os dados relacionados aos carros. Ele contém métodos para buscar, listar, criar e deletar carros.

## Métodos Principais:
- **Integracao(Guid id):** Busca um carro pelo ID.
- **IntegracaoListaCar():** Lista todos os carros disponíveis.
- **IntegracaoCriarCar():** Cria um novo carro enviando os dados para a API.
- **IntegracaoBuscarCarPorStaffId(Guid idStaff):** Busca carros por ID de um Staff específico.
- **IntegracaoDeletarCar(Guid id):** Deleta um carro pelo ID.

# Staff Services

O **StaffServices** gerencia as operações relacionadas a "Staffs". Ele também realiza a integração com a API para realizar operações de busca, listagem, criação e deleção de "Staffs".

## Métodos Principais:
- **Integracao(Guid id):** Busca um staff pelo ID.
- **IntegracaoListaStaff():** Lista todos os staffs disponíveis.
- **IntegracaoCriarStaff():** Cria um novo staff enviando os dados para a API.
- **IntegracaoBuscarStaffIdCar(Guid idCar):** Busca um staff pelo ID de um carro.
- **IntegracaoDeletarStaff(Guid id):** Deleta um staff pelo ID.

- # Dependências
- **Newtonsoft.Json:** Utilizado para serialização e desserialização de JSON.
- **HttpClient:** Usado para fazer as requisições HTTP para a API.

# API Endpoints

## Car API:
- **GET** `/api/Car/BuscarCarPorId/{id}`
- **GET** `/api/Car/ListarCar`
- **POST** `/api/Car/CriarCar`
- **GET** `/api/Car/BuscarCarPorIdStaff/{idStaff}`
- **DELETE** `/api/Car/DeletarCar/{id}`

## Staff API:
- **GET** `/api/Staff/BuscarStaffPorId/{id}`
- **GET** `/api/Staff/ListarStaff`
- **POST** `/api/Staff/CriarStaff`
- **GET** `/api/Staff/BuscarStaffPorIdCarro/{idCar}`
- **DELETE** `/api/Staff/DeletarStaff/{id}`
