using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExercicesControlleursEtVue.Models
{
    public class DataAccess
    {
         const string ChaineConnexionBDD = @"Server=.\sqlexpress;Initial Catalog=Calculatrice;Integrated Security=True";

        public static int GetNombreOperationsEnBdd()
        {
            int nombreOperations;

            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Operation", connection);
                nombreOperations = (int)command.ExecuteScalar();
                connection.Close();
            }

            return nombreOperations;
        }

        public static List<Operation> RecupererListeOperationsEffectuees()
        {
            List<Operation> resultats = new List<Operation>();

            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(
                    @"SELECT OperandeGauche, Operateur, OperandeDroite FROM Operation",
                    connection);

                SqlDataReader reader = requeteSQL.ExecuteReader();

                while (reader.Read())
                {
                    float operandeGauche = (float)reader["OperandeGauche"];
                    float operandeDroite = (float)reader["OperandeDroite"];
                    string operateur = (string)reader["Operateur"];

                    Operation operationCourante = new Operation(operandeGauche, operateur, operandeDroite);
                    resultats.Add(operationCourante);
                }

                connection.Close();
            }

            return resultats;
        }

        public static void EnregistrerOperation(Operation operation)
        {
            using(SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Operation(OperandeGauche, Operateur, OperandeDroite) VALUES (@opeGauche, @operateur, @opeDroite)", connection);
                command.Parameters.AddWithValue("@opeGauche", operation.OperandeGauche);
                command.Parameters.AddWithValue("@opeDroite", operation.OperandeDroite);
                command.Parameters.AddWithValue("@operateur", operation.Operateur);

                command.ExecuteNonQuery();
            }
        }
    }
}