using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextRendererState
{
    protected TextRenderer textRenderer;
    List<int> intList;
    
    public TextRendererState(TextRenderer newTextRenderer) {
        textRenderer = newTextRenderer;
    }

    public void BeginStateBase() {
        BeginState();
    }

    public abstract void BeginState();
}
