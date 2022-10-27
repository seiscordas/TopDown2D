namespace QuestSystem.QuestRewards
{
    public class OpenDoor : QuestReward
    {
        private void Awake()
        {
            OnReward += DoOpenDoor;
        }
        public void DoOpenDoor() => this.gameObject.SetActive(false);
    }
}
