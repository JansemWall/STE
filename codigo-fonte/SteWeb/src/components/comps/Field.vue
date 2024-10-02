<template>
  <div class="form-outline form-white mb-4">
    <input
      :id="id"
      :type="type"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
      :placeholder="placeholder"
      required
      class="form-control form-control-lg"
    />
  </div>
</template>

<script>
export default {
  name: 'Field',
  props: {
    id: {
      type: String,
      required: true
    },
    type: {
      type: String,
      default: 'text'
    },
    modelValue: {
      type: String,
      required: true
    },
    placeholder: {
      type: String,
      required: true
    }
  },
  emits: ['update:modelValue']
}
</script>

<style scoped>
.form-outline {
  margin-bottom: 1rem;
}
input {
  border-radius: 0.5rem;
}
input:focus::placeholder{
  color: transparent;
}
input:focus{
  outline: none;
}
</style>
