using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour, ISelectable
{
    [SerializeField]
    GameObject hpBarPrefab;
    [SerializeField]
    Transform spawnPoint, flag;

    protected HealthBar healthBar;

    public void SetSelected(bool selected)
    {
        flag.gameObject.SetActive(selected);
        healthBar.gameObject.SetActive(selected);
    }

    private void Start()
    {
        Unit.SelectableUnits.Add(this);
        healthBar = Instantiate(hpBarPrefab, transform).GetComponent<HealthBar>();
        SetSelected(false);

    }

    private void OnDestroy()
    {
        Unit.SelectableUnits.Remove(this);
    }

    void Spawn(GameObject prefab)
    {
        var unit = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        unit.SendMessage("Command", flag.position, SendMessageOptions.DontRequireReceiver);
    }

    void Command(Vector3 flagPosition)
    {
        flag.position = flagPosition;
    }

    void Command(Unit unit)
    {
    }
}
