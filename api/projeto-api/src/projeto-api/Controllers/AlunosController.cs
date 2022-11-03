using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using projeto_api.Models;
using System.Data;
using System.Diagnostics;
using System.Net;
using projeto_api.Models.Result;

namespace projeto_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AlunosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                string query = @"
                    select * from alunos
                ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Conn");
                MySqlDataReader myReader;
                using(MySqlConnection mycon=new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        mycon.Close();
                    };
                }

                return new JsonResult(table);

            }
            catch (Exception)
            {
                return new JsonResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("Id/{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                string query = @$"
                    select * from alunos where Ra = '{id}'
                ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Conn");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        mycon.Close();
                    };
                }

                return new JsonResult(table);

            }
            catch (Exception)
            {
                return new JsonResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{cpf}")]
        public JsonResult Get(string cpf)
        {
            try
            {
                string query = @$"
                    select * from alunos where Cpf = '{cpf}'
                ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Conn");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        mycon.Close();
                    };
                }

                return new JsonResult(table);

            }
            catch (Exception)
            {
                return new JsonResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("cadastrar")]
        public JsonResult Post(Alunos alunos)
        {
            Response res = new Response();
            try
            {
                string query = @$"
                    insert into alunos
                        (Ra,Nome,Email,Cpf)
                    values
                        ({alunos.Ra},'{alunos.Nome}','{alunos.Email}','{alunos.Cpf}')
                ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Conn");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        mycon.Close();
                    };
                }

                res.status = (int)HttpStatusCode.OK;
                res.message = "Added Successfully";
                
                return new JsonResult(res);
            }
            catch (Exception ex)
            {
                res.status = (int)HttpStatusCode.InternalServerError;
                res.message = $"Fatal Error: {ex.Message}";

                return new JsonResult(res);
            }
        }

        [HttpPut("atualizar")]
        public JsonResult Put(Alunos alunos)
        {
            Response res = new Response();
            try
            {
                string query = @$"
                    update alunos set
                        Nome = '{alunos.Nome}',
                        Email = '{alunos.Email}',
                        Cpf = '{alunos.Cpf}'
                    where
                        Ra = '{alunos.Ra}'
                ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Conn");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        mycon.Close();
                    };
                }
                res.status = (int)HttpStatusCode.OK;
                res.message = $"Updated Id: {alunos.Ra} Successfully";

                return new JsonResult(res);
            }
            catch (Exception ex)
            {
                res.status = (int)HttpStatusCode.InternalServerError;
                res.message = $"Fatal Error: {ex.Message}";

                return new JsonResult(res);
            }

        }

        [HttpDelete("deletar/{ra}")]
        public JsonResult Delete(int ra)
        {
            Response res = new Response();
            try
            {
                string query = @$"
                    delete from alunos where ra = {ra}
                ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Conn");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        mycon.Close();
                    };
                }

                res.status = (int)HttpStatusCode.OK;
                res.message = $"Deleted Id: {ra} Successfully";

                return new JsonResult(res);
            }
            catch (Exception ex)
            {
                res.status = (int)HttpStatusCode.InternalServerError;
                res.message = $"Fatal Error: {ex.Message}";

                return new JsonResult(res);
            }

        }
    }
}
