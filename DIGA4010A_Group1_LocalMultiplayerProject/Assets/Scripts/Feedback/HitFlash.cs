using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public bool flash;
    private float flashTime;
    [SerializeField] private GameObject flashItem;

    private void Start()
    {
        flashItem = this.transform.GetChild(0).gameObject;
        flashItem.SetActive(false);
    }

    private void Update()
    {
        if (flash == true)
        {
            flashItem.SetActive(true);
            flashTime += Time.deltaTime;
        }

        if (flashTime >= 0.15f)
        {
            flash = false;
            flashItem.SetActive(false);
            flashTime = 0;
        }
    }
}
