namespace Model.Data
{
    public class SaveData<TPropertyType> where TPropertyType : new()
    {
        public TPropertyType Data = new TPropertyType();
    }
}