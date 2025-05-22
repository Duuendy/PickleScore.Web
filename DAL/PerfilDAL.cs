﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using PickleScore.Web.Models;

namespace PickleScore.Web.DAL
{
    public class PerfilDAL
    {
        private readonly string _connectionString;
        public PerfilDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public void SalvarPerfil(Perfil perfil)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                if (perfil.Id == 0)
                {
                    string query = @"INSERT INTO perfil (Nome, DataInsercao, DataAlteracao) 
                                VALUES (@Nome, @DataInsercao, @DataAlteracao)";

                    perfil.DataInsercao = DateTime.Now;
                    perfil.DataAlteracao = DateTime.Now;
                    connection.Execute(query, perfil);

                }
                else
                {
                    atualizarPerfil(perfil);
                }

            }
        }

        public Perfil CarregarPerfil(int id)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM perfil WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Perfil>(query, new { Id = id });
            }
        }

        private void atualizarPerfil(Perfil perfil)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                perfil.DataAlteracao = DateTime.Now;
                string query = @"UPDATE perfil 
                                SET Nome = @Nome, 
                                DataAlteracao = @DataAlteracao 
                                WHERE Id = @Id";
                perfil.DataAlteracao = DateTime.Now;
                connection.Execute(query, perfil);
            }
        }

        public void DeletarPerfil(int id)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"DELETE FROM perfil WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

        public void ListarPerfis()
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM perfil";
                var perfis = connection.Query<Perfil>(query).ToList();
            }
        }
    }
}