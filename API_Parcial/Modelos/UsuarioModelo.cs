namespace API_Parcial.Modelos
{
    public class UsuarioModelo
    {

        public int idUsuario { get; set; }
        public int idPersona { get; set; }
        public string nombre_usuario { get; set; }
        public string contraseña { get; set; }
        public string nivel { get; set; }
        public string estado { get; set; }
    }
}
