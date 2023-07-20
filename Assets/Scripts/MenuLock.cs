using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class MenuLock : MonoBehaviour
{
    [SerializeField] private Text _menuText;

    public void Action()
    {
        GetComponent<PlayerMovement>().enabled = true;
        _menuText.gameObject.SetActive(false);
    }
}
