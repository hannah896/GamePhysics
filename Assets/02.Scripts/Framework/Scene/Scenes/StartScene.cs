using UnityEngine;

public class StartScene : SceneBase
{

    public async override void OnEnter()
    {
        await Managers.Resource.LoadAsync<AudioClip>("Assets/03.Prefabs/Map/Correct");
        await Managers.Resource.LoadAsync<AudioClip>("Assets/03.Prefabs/Map/Correct");
        await Managers.Resource.LoadAsync<AudioClip>("Assets/03.Prefabs/Map/Correct");
    }
    

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
