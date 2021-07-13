using Flunt.Notifications;
using System;
using System.Data.SqlClient;

namespace Infrastructure.Data.DataBase
{
    public class SqlServer : Notifiable<Notification>, IConection
    {
        public SqlConnection SqlConnection { get; private set; }

        public SqlServer()
        {
            Conect();
        }

        public void Conect()
        {
            try
            {
                SqlConnection = new SqlConnection("<connection_string>");
            }
            catch (Exception)
            {
                AddNotification(new Notification("Erro", "Não foi possível conectar-se a base da dados"));
            }
        }

        public void Disconect() => SqlConnection.Dispose();
    }
}