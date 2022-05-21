namespace BLL.Enum
{
    public enum IntegrityStatus
    {
        INTEGRITY_IS_INTACT, //Целостность не повреждена
        INTEGRITY_IS_COMPROMISED, //Целостность нарушена
        INTEGRITY_IS_BROKEN_BUT_HAS_BEEN_RESTORED, //Целостность нарушена, но была восстановлена
        UNKNOWN_ERROR //Неизвестная ошибка
    }
}
