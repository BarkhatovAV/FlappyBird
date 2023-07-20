using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class StartGame : MonoBehaviour
{
    [SerializeField] private Text _menuText;

    public void Action()
    {
        GetComponent<PlayerMovement>().enabled = true;
        if(_menuText)
            _menuText.gameObject.SetActive(false);
    }
}
