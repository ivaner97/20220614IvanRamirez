using Citas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Citas.Context
{
    public class DBContext
    {
        readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Citas;";
        
        //CLIENTE
        public IEnumerable<Cliente> GetClientes()
        {
            var ClienteList = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var cliente = new Cliente();
                    cliente.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cliente.Dui = dr["Dui"].ToString();
                    cliente.Nombre = dr["Nombre"].ToString();
                    cliente.Apellido = dr["Apellido"].ToString();
                    cliente.Telefono = dr["Telefono"].ToString();

                    ClienteList.Add(cliente);
                }

                con.Close();
            }

            return ClienteList;
        }

        public Cliente GetClientes(int id)
        {
            var cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id",id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cliente.Dui = dr["Dui"].ToString();
                    cliente.Nombre = dr["Nombre"].ToString();
                    cliente.Apellido = dr["Apellido"].ToString();
                    cliente.Telefono = dr["Telefono"].ToString();
                }

                con.Close();
            }

            return cliente;
        }

        public void CreateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Dui", cliente.Dui);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@Dui", cliente.Dui);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteCliente(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //MEDICO
        public IEnumerable<Medico> GetMedico()
        {
            var MedicoList = new List<Medico>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var medico = new Medico();
                    medico.IdMedico = Convert.ToInt32(dr["IdMedico"].ToString());

                    medico.Nombre = dr["Nombre"].ToString();
                    medico.Apellido = dr["Apellido"].ToString();

                    MedicoList.Add(medico);
                }

                con.Close();
            }

            return MedicoList;
        }

        public Medico GetMedico(int id)
        {
            var medico = new Medico();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    medico.IdMedico = Convert.ToInt32(dr["IdMedico"].ToString());
                    medico.Nombre = dr["Nombre"].ToString();
                    medico.Apellido = dr["Apellido"].ToString();
                }

                con.Close();
            }

            return medico;
        }

        public void CreateMedico(Medico medico)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", medico.Apellido);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateMedico(Medico medico)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", medico.IdMedico);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", medico.Apellido);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteMedico(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteMedico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //Cita
        public IEnumerable<Cita> GetCita()
        {
            var CitaList = new List<Cita>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCita", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var cita = new Cita();
                    cita.IdCita = Convert.ToInt32(dr["IdCita"].ToString());
                    cita.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    cita.Hora = Convert.ToDateTime(dr["Hora"].ToString());
                    cita.Idcliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cita.Idmedico = Convert.ToInt32(dr["IdMedico"].ToString());
                    cita.cliente = dr["Cliente"].ToString();
                    cita.medico = dr["Medico"].ToString();

                    CitaList.Add(cita);
                }

                con.Close();
            }

            return CitaList;
        }

        public Cita GetCita(int id)
        {
            var cita = new Cita();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCita", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cita.IdCita = Convert.ToInt32(dr["IdCita"].ToString());
                    cita.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    cita.Hora = Convert.ToDateTime(dr["Hora"].ToString());
                    cita.Idcliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cita.Idmedico = Convert.ToInt32(dr["IdMedico"].ToString());
                    cita.cliente = dr["Cliente"].ToString();
                    cita.medico = dr["Medico"].ToString();
                }

                con.Close();
            }

            return cita;
        }

        public IEnumerable<Cita> GetCitaFin()
        {
            var CitaList = new List<Cita>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCitaFin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var cita = new Cita();
                    cita.IdCita = Convert.ToInt32(dr["IdCita"].ToString());
                    cita.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    cita.Hora = Convert.ToDateTime(dr["Hora"].ToString());
                    cita.Idcliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cita.Idmedico = Convert.ToInt32(dr["IdMedico"].ToString());
                    cita.cliente = dr["Cliente"].ToString();
                    cita.medico = dr["Medico"].ToString();
                    cita.diagnostico = dr["Diagnostico"].ToString();
                    cita.estado = Convert.ToInt32(dr["estado"].ToString());

                    CitaList.Add(cita);
                }

                con.Close();
            }

            return CitaList;
        }

        public void CreateCita(Cita cita)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddCita", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@hora", cita.Hora);
                cmd.Parameters.AddWithValue("@cliente", cita.Idcliente);
                cmd.Parameters.AddWithValue("@medico", cita.Idmedico);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateCita(Cita cita)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCita", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", cita.IdCita);
                cmd.Parameters.AddWithValue("@fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@hora", cita.Hora);
                cmd.Parameters.AddWithValue("@cliente", cita.Idcliente);
                cmd.Parameters.AddWithValue("@medico", cita.Idmedico);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteCita(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCita", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void FinalizarCita(Cita cita)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_FinCita", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", cita.IdCita);
                cmd.Parameters.AddWithValue("@estado", cita.estado);
                cmd.Parameters.AddWithValue("@diagnostico", cita.diagnostico);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
