
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Interfaz")]
    //[SerializeField] int volumenMusica;
    //[SerializeField] int volumenAudio;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelNiveles;
    [SerializeField] private GameObject panelGameName;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelLogros;
    [SerializeField] private GameObject panelCreditos;
    //[SerializeField] private GameObject panelHabilidades;
    //[SerializeField] private GameObject panelTienda;
    //[SerializeField] private GameObject panelSkins;
    //[SerializeField] private GameObject panelInventario;
    //[SerializeField] private GameObject panelMisiones;
    


    // [SerializeField] public int panelIntro; // panel se muestra solo una vez
    // [SerializeField] private int Compra; // panel se muestra solo una vez


    [Header("Volumen")]
    [SerializeField] private Slider MusicVolumeSlider;
    [SerializeField] private Slider AudioVolumeSlider;

    [Header("First Selectable Menu")]

    public GameObject GO_principal;
    public GameObject GO_new_game;
    public GameObject GO_load_game;
    public GameObject GO_options;
    public GameObject GO_unlocked;
    public GameObject GO_credits;
    public GameObject GO_exit;

    public Button CancelOptions;

    public void Menu()
    {
        panelOpciones.SetActive(false);
        panelMenu.SetActive(true);
    }


    public void Niveles()
    {
        panelMenu.SetActive(false);
        panelNiveles.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_load_game);
    }

    public void NivelesBack()
    {
        panelMenu.SetActive(true);
        panelNiveles.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_principal);
    }

    public void GameName()
    {
        panelMenu.SetActive(false);
        panelGameName.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_new_game);
    }

    public void GameNameBack()
    {
        panelMenu.SetActive(true);
        panelGameName.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_principal);
    }
    public void Options()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_options);
    }


    public void OptionsBack()
    {
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_principal);
    }


    public void Logros()
    {
        panelMenu.SetActive(false);
        panelLogros.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_unlocked);

    }

    public void LogrosBack()
    {
        panelMenu.SetActive(true);
        panelLogros.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_principal);
    }


    public void Creditos()
    {
        panelMenu.SetActive(false);
        panelCreditos.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_credits);
    }

    public void CreditosBack()
    {
        panelMenu.SetActive(true);
        panelCreditos.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GO_principal);

    }

    //public void Habilidades()
    //{
    //    panelMenu.SetActive(false);
    //    panelHabilidades.SetActive(true);
    //}

    //public void HabilidadesBack()
    //{
    //    panelMenu.SetActive(true);
    //    panelHabilidades.SetActive(false);

    //}

    //public void Tienda()
    //{
    //    panelMenu.SetActive(false);
    //    panelTienda.SetActive(true);
    //}

    //public void TiendaBack()
    //{
    //    panelMenu.SetActive(true);
    //    panelTienda.SetActive(false);

    //}

    //public void Skins()
    //{
    //    panelMenu.SetActive(false);
    //    panelSkins.SetActive(true);
    //}

    //public void SkinsBack()
    //{
    //    panelMenu.SetActive(true);
    //    panelSkins.SetActive(false);

    //}

    //public void Inventario()
    //{
    //    panelMenu.SetActive(false);
    //    panelInventario.SetActive(true);
    //}

    //public void InventarioBack()
    //{
    //    panelMenu.SetActive(true);
    //    panelInventario.SetActive(false);

    //}

    //public void Misiones()
    //{
    //    panelMenu.SetActive(false);
    //    panelMisiones.SetActive(true);
    //}

    //public void MisionesBack()
    //{
    //    panelMenu.SetActive(true);
    //    panelMisiones.SetActive(false);

    //}


    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {

            if (panelGameName.activeInHierarchy)
            {

                GameNameBack();
            }
            else if (panelOpciones.activeInHierarchy)
            {

                OptionsBack();
            }
            else if (panelLogros.activeInHierarchy)
            {
                LogrosBack();
            }
            else if (panelNiveles.activeInHierarchy)
            {
                NivelesBack();
            }
            else if (panelCreditos.activeInHierarchy)
            {
                CreditosBack();
            }
            //else if (panelHabilidades.activeInHierarchy)
            //{
            //    HabilidadesBack();
            //}
            //else if (panelTienda.activeInHierarchy)
            //{
            //    TiendaBack();
            //}
            //else if (panelSkins.activeInHierarchy)
            //{
            //    SkinsBack();
            //}
            //else if (panelInventario.activeSelf)
            //{
            //    InventarioBack();
            //}
            //else if (panelMisiones.activeSelf)
            //{
            //    InventarioBack();
            //}

            else
            {
                Debug.Log("No funciona");
                panelMenu.SetActive(true);
            }
        }
        
    }
}
