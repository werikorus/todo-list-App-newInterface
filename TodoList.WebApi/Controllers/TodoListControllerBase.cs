using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebApi.Controllers;

[ApiController, Route("api/v{version:apiVersion}/[Controller]")]

public class TodoListControllerBase : ControllerBase { } 
