using UnityEngine;

public class DialogMgr : MonoBehaviour {

    private bool conversationStarted;
    public enum robotState { Inactivo, hablando, escuchando}
    public robotState state;
    private float count;
    public bool activo;
    public Renderer e_i, e_d;
    public Material normal, rojo, verde;

    private void Update()
    {
        switch (state)
        {
            case robotState.hablando:
                e_i.material = rojo;
                e_d.material = rojo;
                count += Time.deltaTime;
                if (!RobotMgr.instance.speechManager.audioSource.isPlaying && count > 2)
                {
                    if (activo)
                    {
                        state = robotState.escuchando;
                    }
                    else
                    {
                        state = robotState.Inactivo;
                    }
                }
                break;
            case robotState.escuchando:
                e_i.material = verde;
                e_d.material = verde;
                RobotMgr.instance.microphoneManager.StartCapturingAudio();
                break;
            default:
                e_i.material = normal;
                e_d.material = normal;
                break;
        }
    }

    public void DictationProcess(string dic)
    {
        if (activo)
        {
            string texto_out = dic.ToLower();
            if (!conversationStarted)
            {
                conversationStarted = true;
                texto_out = "Hola. Soy Robochachi. Puedes hablar conmigo, pero solo te escucharé cuando tenga los ojitos verdes";
            }
            else
            {
                if (dic.Contains("desconecta"))
                {
                    texto_out = "Muy bien. Hasta luego machote";
                    activo = false;
                    conversationStarted = false;
                }
                else
                {
                    if (dic.Contains("tiempo") && dic.Contains("mañana"))
                    {
                        texto_out = "Creo que mañana va a llover. Eso no es bueno para mis circuitos.";
                    }
                    else if (dic.Contains("realidad") && dic.Contains("mixta"))
                    {
                        texto_out = "Sin duda la realidad mixta es el futuro... por la cuenta que me trae.";
                    }
                    else if (dic.Contains("xxxxx"))
                    {
                        texto_out = "Apagando sistema....";
                        activo = false;
                        conversationStarted = false;
                    }
                    else if (dic.Contains("repite conmigo"))
                    {
                        texto_out = "Has dicho... " + texto_out;
                    }
                    else
                    { 
                        int r = Random.Range(0,6);
                        switch (r)
                        {
                            case 1:
                                texto_out = "¿que tiempo hará mañana?... eso si es una pregunta interesante.";
                                break;
                            case 2:
                                texto_out = "No se que quieres decir. Pero si te sirve de algo, mi color favorito es el azul.";
                                break;
                            case 3:
                                texto_out = "La vida de un robot es dura. Aveces no entiendo a los humanos.";
                                break;
                            case 4:
                                texto_out = "Porque no me preguntas sobre la realidad mixta... por ejemplo.";
                                break;
                            case 5:
                                texto_out = "También se repetir tus palabras... si me lo pides.";
                                break;
                            default:
                                texto_out = "En realidad no soy tan listo aún. Dame un poco de tiempo.";
                                break;
                        }

                    }
                }
            }
            RobotMgr.instance.speechManager.Speak(texto_out);
            count = 0;
            state = robotState.hablando;
        }
    }

}
