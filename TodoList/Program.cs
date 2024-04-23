var todoList = new List<string>();

Console.WriteLine("Welcome to your TODO list manager!");

bool shallExit = false;

while (!shallExit)
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    var userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        case "E":
        case "e":
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid input!");
            break;
    }
}

void SeeAllTodos()
{
    if (todoList.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    else
    {
        for (int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todoList[i]}");
        }
    }
}

void AddTodo()
{
    string userDescription;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        userDescription = Console.ReadLine();
    }
    while (!IsDescriptionValid(userDescription));

    todoList.Add(userDescription);

}

bool IsDescriptionValid(string userDescription)
{
    if (userDescription == "")
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    if (todoList.Contains(userDescription))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;
}

void RemoveTodo()
{
    if (todoList.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove.");
        SeeAllTodos();
    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}

void RemoveTodoAtIndex(int index)
{
    var todoToBeRemoved = todoList[index];
    todoList.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToBeRemoved);

}

bool TryReadIndex(out int index)
{
    var selectedIndex = Console.ReadLine();
    if (selectedIndex == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }
    if (int.TryParse(selectedIndex, out index) &&
       index >= 1 &&
       index <= todoList.Count)
    {
        return true;
    }
    Console.WriteLine("The given index is not valid.");
    return false;
}

static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}
