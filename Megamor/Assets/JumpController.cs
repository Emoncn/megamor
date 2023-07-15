using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private bool isJumping = false;

    private IEnumerator JumpCoroutine()
    {
        // Enregistrer la position initiale de l'objet
        Vector3 initialPosition = transform.position;

        // Calculer la position cible du saut
        Vector3 targetPosition = initialPosition + Vector3.up;

        // Durée totale du saut (2 secondes)
        float jumpDuration = 2f;

        // Temps écoulé depuis le début du saut
        float elapsedTime = 0f;

        // Tant que la durée du saut n'est pas atteinte
        while (elapsedTime < jumpDuration)
        {
            // Calculer la progression du saut (entre 0 et 1)
            float jumpProgress = elapsedTime / jumpDuration;

            float cosIt = jumpProgress * Mathf.PI;

            // Interpoler la position de l'objet entre l'initial et le cible
            transform.position = Vector3.Lerp(initialPosition, targetPosition, Mathf.Sin(cosIt));

            // Mettre à jour le temps écoulé
            elapsedTime += Time.deltaTime;

            // Attendre le prochain frame
            yield return null;
        }

        // Remettre l'objet à sa position initiale
        //transform.position = initialPosition;

        // Le saut est terminé
        isJumping = false;
    }

    private void Update()
    {
        // Vérifier si la touche espace est enfoncée et si le saut n'est pas déjà en cours
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            // Démarrer la coroutine de saut
            StartCoroutine(JumpCoroutine());
            isJumping = true;
        }
    }
}
