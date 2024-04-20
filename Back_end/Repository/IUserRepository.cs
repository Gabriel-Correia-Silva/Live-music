using Back_end.Models;

namespace Back_end.Repository;

public interface IUserRepository
{
    //Listar todos os usuários
    Task<List<UserModel>> AllUsers();
    
    //Listar um usuário
    Task<UserModel> GetUser(int id);
    
    //Adicionar um usuário
    Task<UserModel> AddUser(UserModel user);
    
    //Atualizar um usuário
    Task<UserModel> UpdateUser(UserModel user);
    
    //Deletar um usuário
    Task<UserModel> DeleteUser(int id);
}