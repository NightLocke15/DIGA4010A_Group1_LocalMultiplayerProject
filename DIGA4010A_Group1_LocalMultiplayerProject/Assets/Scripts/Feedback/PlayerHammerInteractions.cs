using UnityEngine;
using UnityEngine.UI;

public class PlayerHammerInteractions : MonoBehaviour
{
    [SerializeField] private Slider otherPlayerHealth;
    [SerializeField] private SpriteRenderer otherPlayerObjectBounds;
    [SerializeField] private SpriteRenderer thisHammerObjectBounds;

    private void Start()
    {
        

        thisHammerObjectBounds = this.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(thisHammerObjectBounds.bounds.extents);
    }
}
