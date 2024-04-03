using System.Globalization;
using TodoList.Domain.Abstraction;

namespace TodoList.Domain.Entities.Users;

public class User : Entity<Guid>
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string UrlAvatar { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }

    internal User(Guid id, string name, string password, string email, string role, string urlAvatar, DateTime dateCreate, DateTime dateUpdate)
    {
        SetId(id);
        SetName(name);
        SetPassword(password);
        SetEmail(email);
        SetRole(role);
        SetUrlAvatar(urlAvatar);
        SetDateCreate(dateCreate);
        SetDateUpdate(dateUpdate);
    }

    protected User(Guid id)
    {
    }

    protected override void SetId(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_Id_invalid);
            return;
        }

        Id = id;
    }

    private void SetName(string name)
    {
        if (name.Equals(string.Empty))
        {
            Notification.AddError(DomainResource.TodoList_Name_invalid);
            return;
        }

        Name = name;
    }

    private void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            Notification.AddError(DomainResource.TodoList_Password_invalid);
            return;
        }

        Password = password;
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            Notification.AddError(DomainResource.TodoList_Email_invalid);
            return;
        } 

        Email = email;
    }

    private void SetRole(string role)
    {
        if (string.IsNullOrEmpty(role))
        {
            Notification.AddError(DomainResource.TodoList_Role_invalid);
            return;
        }

        Role = role;
    }

    private void SetUrlAvatar(string urlAvatar)
    {
        UrlAvatar = urlAvatar;
    }

    private void SetDateCreate(DateTime dateCreate)
    {
        if (string.IsNullOrEmpty(dateCreate.ToString(CultureInfo.InvariantCulture)))
        {
            Notification.AddError(DomainResource.TodoList_DateCreate_invalid);
            return;
        }

        DateCreate = dateCreate;
    }

    private void SetDateUpdate(DateTime dateUpdate)
    {
        if (string.IsNullOrEmpty(dateUpdate.ToString(CultureInfo.InvariantCulture)))
        {
            Notification.AddError(DomainResource.TodoList_DateUpdate_invalid);
            return;
        }

        DateUpdate = dateUpdate;
    }
}