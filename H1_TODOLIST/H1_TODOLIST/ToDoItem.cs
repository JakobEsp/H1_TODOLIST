
namespace H1_TODOLIST
{
    internal class ToDoItem
    {
        public DateTime created;
        public DateTime deadLine;
        public long? repeat;
        public string whatToDo;
        public bool isDone { get; set; }
        public bool isFavorite { get; set; }

        public ToDoItem(DateTime created, DateTime deadLine, long? repeat, string whatToDo, bool isDone, bool isFavorite)
        {
            this.created = created;
            this.deadLine = deadLine;
            this.repeat = repeat;
            this.whatToDo = whatToDo;
            this.isDone = isDone;
            this.isFavorite = isFavorite;
        }
    }
}
