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
                    cita.Hora = dr["Hora"].ToString();
                    cita.cliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cita.medico = Convert.ToInt32(dr["IdMedico"].ToString());

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
                    cita.Hora = dr["Hora"].ToString();
                    cita.cliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    cita.medico = Convert.ToInt32(dr["IdMedico"].ToString());
                }

                con.Close();
            }

            return cita;
        }

        public void CreateCita(Cita cita)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddCita", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@hora", cita.Hora);
                cmd.Parameters.AddWithValue("@cliente", cita.cliente);
                cmd.Parameters.AddWithValue("@medico", cita.medico);

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
                cmd.Parameters.AddWithValue("@cliente", cita.cliente);
                cmd.Parameters.AddWithValue("@medico", cita.medico);

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

         //Diagnostico
        public IEnumerable<Diagnostico> GetDiagnostico()
        {
            var DiagnosticoList = new List<Diagnostico>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetDiagnostico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var diagnostico = new Diagnostico();
                    diagnostico.Id = Convert.ToInt32(dr["Id"].ToString());
                    diagnostico.CIta = Convert.ToInt32(dr["IdCita"].ToString());
                    diagnostico.Descripcion = dr["Descripcion"].ToString();

                    DiagnosticoList.Add(diagnostico);
                }

                con.Close();
            }

            return DiagnosticoList;
        }

        public Diagnostico GetDiagnostico(int id)
        {
            var diagnostico = new Diagnostico();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetDiagnostico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    diagnostico.Id = Convert.ToInt32(dr["Id"].ToString());
                    diagnostico.CIta = Convert.ToInt32(dr["IdCita"].ToString());
                    diagnostico.Descripcion = dr["Descripcion"].ToString();
                }

                con.Close();
            }

            return diagnostico;
        }

        public void CreateDiagnostico(Diagnostico diagnostico)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddDiagnostico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cita", diagnostico.CIta);
                cmd.Parameters.AddWithValue("@descripcion", diagnostico.Descripcion);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateDiagnostico(Diagnostico diagnostico)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateDiagnostico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", diagnostico.Id);
                cmd.Parameters.AddWithValue("@cita", diagnostico.CIta);
                cmd.Parameters.AddWithValue("@descripcion", diagnostico.Descripcion);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteDiagnostico(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteDiagnostico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
