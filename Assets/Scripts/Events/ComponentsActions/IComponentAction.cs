public enum EnumComponentGroupAction
{
    move,
    attack,//прицеливание. Когда игрок жмет по 
    collect
}

public enum EnumComponentAction
{
    aim,
    shoot,
    reload,
    cooldown
}

public interface IComponentAction
{
    EnumComponentAction Action { get; }
    EnumComponentGroupAction GroupAction { get; }
}
