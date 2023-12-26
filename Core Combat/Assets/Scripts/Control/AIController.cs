using RPG.Combat;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chanceDistance = 5f;
        Fighter fighter;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {
            if (InRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }
        
        private bool InRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chanceDistance;
        }
    }
}