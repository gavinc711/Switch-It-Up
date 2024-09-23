using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button[] buttons;
    private int selectedIndex = 0;

    private void OnEnable()
    {
        // Set the first button selected
        SelectButton(selectedIndex);
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (context.ReadValue<Vector2>().y > 0)
            {
                selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : buttons.Length - 1;
            }
            else if (context.ReadValue<Vector2>().y < 0)
            {
                selectedIndex = (selectedIndex < buttons.Length - 1) ? selectedIndex + 1 : 0;
            }
            SelectButton(selectedIndex);
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttons[selectedIndex].onClick.Invoke();
        }
    }

    private void SelectButton(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (i == index);
        }
        buttons[index].Select();
    }
}