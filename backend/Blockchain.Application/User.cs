namespace Blockchain.Application
{
    public class User
    {
        public User(string legajo, string nombre, UserRole role)
        {
            Nombre = nombre;
            Role = role;
            Legajo = legajo;
        }

        public string Legajo { get; }
        public string Nombre { get; }
        public UserRole Role { get; }
    }

    public enum UserRole
    {
        Profesor,
        Alumno
    }
}
