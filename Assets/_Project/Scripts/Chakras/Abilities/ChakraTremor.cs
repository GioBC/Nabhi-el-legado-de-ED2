using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

namespace NABHI.Chakras.Abilities
{
    /// <summary>
    /// Chakra 3: Temblor
    /// Color: Verde - Corazon (Amor y Cura)
    ///
    /// Crea un fuerte temblor en un area corta alrededor del personaje.
    /// - Noquea temporalmente a los enemigos
    /// - Destruye estructuras fragiles en el entorno
    /// </summary>
    public class ChakraTremor : ChakraBase
    {
        [Header("Tremor Settings")]
        [Tooltip("Radio del efecto de temblor")]
        [SerializeField] private float tremblRadius = 5f;

        [Tooltip("Duracion del aturdimiento en enemigos")]
        [SerializeField] private float stunDuration = 2f;

        [Tooltip("Fuerza del knockback aplicado")]
        [SerializeField] private float knockbackForce = 8f;

        [Header("Damage")]
        [Tooltip("Dano aplicado a enemigos")]
        [SerializeField] private int damage = 10;

        [Tooltip("Dano a estructuras fragiles")]
        [SerializeField] private int structureDamage = 50;

        [Header("Layers")]
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private LayerMask destructibleLayer;

        [Header("Visual")]
        [SerializeField] private ParticleSystem tremblParticles;
        [SerializeField] private float screenShakeIntensity = 0.5f;
        [SerializeField] private float screenShakeDuration = 0.3f;

        [Header("Audio")]
        [SerializeField] private AudioClip tremblSound;

        private AudioSource audioSource;

        protected override void Awake()
        {
            base.Awake();

            // Configurar tipo
            chakraType = ChakraType.Tremor;
            chakraName = "Temblor";
            chakraColor = new Color(0.2f, 0.8f, 0.4f); // Verde
            activationMode = ChakraActivationMode.Instant;
            cooldown = 3f;

            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        protected override void OnActivate()
        {
            // Ejecutar el temblor
            ExecuteTrembl();

            // Los chakras instantaneos se "desactivan" inmediatamente
            StartCoroutine(InstantDeactivate());
        }

        private IEnumerator InstantDeactivate()
        {
            yield return null;
            isActive = false;
        }

        private void ExecuteTrembl()
        {
            Vector2 origin = transform.position;

            // Detectar enemigos
            Collider2D[] enemies = Physics2D.OverlapCircleAll(origin, tremblRadius, enemyLayer);
            foreach (var enemyCollider in enemies)
            {
                ApplyTremblToEnemy(enemyCollider, origin);
            }

            // Detectar estructuras destruibles
            Collider2D[] destructibles = Physics2D.OverlapCircleAll(origin, tremblRadius, destructibleLayer);
            foreach (var destructible in destructibles)
            {
                ApplyTremblToStructure(destructible);
            }

            // Efectos visuales
            if (tremblParticles != null)
            {
                tremblParticles.Play();
            }

            // Screen shake
            TriggerScreenShake();

            // Sonido
            if (tremblSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(tremblSound);
            }

            Debug.Log($"[ChakraTremor] Temblor ejecutado! Enemigos afectados: {enemies.Length}, Estructuras: {destructibles.Length}");
        }

        private void ApplyTremblToEnemy(Collider2D enemyCollider, Vector2 origin)
        {
            // Aplicar dano si tiene interface de dano
            var damageable = enemyCollider.GetComponent<Character.IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }

            // Aplicar knockback
            Rigidbody2D rb = enemyCollider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = ((Vector2)enemyCollider.transform.position - origin).normalized;
                rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            }

            // Aplicar stun si tiene componente de enemigo
            var stunnable = enemyCollider.GetComponent<IStunnable>();
            if (stunnable != null)
            {
                stunnable.ApplyStun(stunDuration);
            }
        }

        private void ApplyTremblToStructure(Collider2D structureCollider)
        {
            // Buscar componente de estructura destruible
            var destructible = structureCollider.GetComponent<IDestructible>();
            if (destructible != null)
            {
                destructible.TakeDamage(structureDamage);
            }
        }

        private void TriggerScreenShake()
        {
            // Screen shake simple usando la camara principal
            if (Camera.main != null)
            {
                StartCoroutine(ShakeCamera());
            }
        }

        private IEnumerator ShakeCamera()
        {
            Transform camTransform = Camera.main.transform;
            Vector3 originalPos = camTransform.localPosition;
            float elapsed = 0f;

            while (elapsed < screenShakeDuration)
            {
                float x = Random.Range(-1f, 1f) * screenShakeIntensity;
                float y = Random.Range(-1f, 1f) * screenShakeIntensity;

                camTransform.localPosition = originalPos + new Vector3(x, y, 0);

                elapsed += Time.deltaTime;
                yield return null;
            }

            camTransform.localPosition = originalPos;
        }

        protected override void OnDeactivate()
        {
            // No hace nada especial al desactivar (es instantaneo)
        }

        protected override string GetChakraDescription()
        {
            return $"Crea un temblor que noquea enemigos y destruye estructuras fragiles en un radio de {tremblRadius} unidades.";
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = chakraColor;
            Gizmos.DrawWireSphere(transform.position, tremblRadius);
        }
    }

    /// <summary>
    /// Interface para objetos que pueden ser aturdidos
    /// </summary>
    public interface IStunnable
    {
        void ApplyStun(float duration);
        bool IsStunned { get; }
    }

    /// <summary>
    /// Interface para objetos destruibles
    /// </summary>
    public interface IDestructible
    {
        void TakeDamage(int damage);
        bool IsDestroyed { get; }
    }
}
