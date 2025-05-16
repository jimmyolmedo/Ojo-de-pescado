using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    [SerializeField] private string m_initialIdentifier;

    [SerializeField] private List<Panel> m_panels;

    public string CurrentIdentifier { get; private set; }

    private void OnEnable()
    {
        SwitchPanel(m_initialIdentifier, true);
    }

    public void SwitchPanel(string identifier) => SwitchPanel(identifier, false);
    public void SwitchPanel(string identifier, bool instant)
    {
        CurrentIdentifier = identifier;

        foreach (Panel panel in m_panels)
        {
            bool active = panel.Identifier == identifier;

            if (instant)
            {
                panel.Set(active);
                continue;
            }

            if (active) panel.Open();
            else panel.Close();
        }
    }
}