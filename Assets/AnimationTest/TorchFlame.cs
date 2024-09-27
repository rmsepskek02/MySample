using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class TorchFlame : MonoBehaviour
    {
        #region Variables
        public Transform torchLight;    //��ġ����Ʈ ��ü
        private Animation flameAnim;

        //1�� Ÿ�̸�
        [SerializeField] private float flameTimer = 1f;
        private float countdown = 0f;

        private int lightMode;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //�ʱ�ȭ
            flameAnim = torchLight.GetComponent<Animation>();
            lightMode = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(lightMode == 0)
            {
                StartCoroutine(FlameAnimation());
            }
            

            /*//1�ʸ��� 1���� ������ ����Ʈ �ִϸ��̼���  �÷���
            if (countdown <= 0f)
            {
                //���� �ִϸ��̼� �÷���
                LightAnimation();

                //�ʱ�ȭ
                countdown = flameTimer;
            }
            countdown -= Time.deltaTime;*/
        }

        IEnumerator FlameAnimation()
        {
            lightMode = Random.Range(1, 4);

            switch (lightMode)
            {
                case 1:
                    flameAnim.Play("TorchLightAnim01");
                    break;
                case 2:
                    flameAnim.Play("TorchLightAnim02");
                    break;
                case 3:
                    flameAnim.Play("TorchLightAnim03");
                    break;
            }

            yield return new WaitForSeconds(1.0f);

            lightMode = 0;
        }

        //���� �ִϸ��̼� �÷���
        void LightAnimation()
        {
            lightMode = Random.Range(1, 4);

            switch(lightMode)
            {
                case 1:
                    flameAnim.Play("TorchLightAnim01");
                    break;
                case 2:
                    flameAnim.Play("TorchLightAnim02");
                    break;
                case 3:
                    flameAnim.Play("TorchLightAnim03");
                    break;
            }
        }
    }
}