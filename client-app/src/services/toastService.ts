import { createToastInterface, POSITION, TYPE } from 'vue-toastification';

const toast = createToastInterface({
  position: POSITION.TOP_RIGHT,
  timeout: 5000,
  closeOnClick: true,
  pauseOnFocusLoss: true,
  pauseOnHover: true,
  draggable: true,
  draggablePercent: 0.6,
  showCloseButtonOnHover: false,
  hideProgressBar: false,
  closeButton: 'button',
  icon: true,
  rtl: false,
});

const success = (message: string) => {
  toast.success(message, { type: TYPE.SUCCESS });
};

const error = (message: string) => {
  toast.error(message, { type: TYPE.ERROR });
};

const info = (message: string) => {
  toast.info(message, { type: TYPE.INFO });
};

const warning = (message: string) => {
  toast.warning(message, { type: TYPE.WARNING });
};

export default {
  success,
  error,
  info,
  warning,
};
